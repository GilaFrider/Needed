using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Repositories.ApiRepo;
using Repositories.Models;
using Services.ApiService;
using Services.DTO;
using BCrypt.Net;
using System.Net.Mail;
using System.Net;


namespace Services.ImplementationService
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepo _employerRepo;
        private readonly IMapper _mapper;

        public EmployerService(IEmployerRepo employerRepo, IMapper mapper)
        {
            _employerRepo = employerRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployerDTO>> GetAllAsync()
        {
            var employers = await _employerRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployerDTO>>(employers);
        }

        public async Task<EmployerDTO> GetByIdAsync(int id)
        {
            var employer = await _employerRepo.GetByIdAsync(id);
            return _mapper.Map<EmployerDTO>(employer);
        }

        public async Task CreateAsync(EmployerDTO employerDto)
        {
            var employer = _mapper.Map<Employer>(employerDto);

            // Hash the password
            if (!string.IsNullOrEmpty(employerDto.Password))
            {
                employer.Password = BCrypt.Net.BCrypt.HashPassword(employerDto.Password);
            }

            await _employerRepo.CreateAsync(employer);
        }

        public async Task UpdateAsync(EmployerDTO employerDto)
        {
            var employer = _mapper.Map<Employer>(employerDto);
            await _employerRepo.UpdateAsync(employer);
        }

        public async Task DeleteAsync(int id)
        {
            await _employerRepo.DeleteAsync(id);
        }

        public async Task<EmployerDTO> LoginAsync(string email, string password)
        {
            var employer = await _employerRepo.GetByEmailAsync(email);
            if (employer == null || !BCrypt.Net.BCrypt.Verify(password, employer.Password))
            {
                return null; // Invalid email or password
            }
            return _mapper.Map<EmployerDTO>(employer);
        }


        public async Task SendCvAsync(int employerId, Stream cvStream, string cvFileName, string message)
        {
            var employer = await _employerRepo.GetByIdAsync(employerId);
            if (employer == null)
            {
                throw new Exception("Employer not found.");
            }

            var fromAddress = new MailAddress("g0548457103@gmail.com", "Needed");
            var toAddress = new MailAddress(employer.Email);
            const string fromPassword = "dari bkzt mbll ipew"; // Replace with secure handling
            const string subject = "New CV Submission";
            string body = message;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            })
            using (var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                // Attach the CV
                mailMessage.Attachments.Add(new Attachment(cvStream, cvFileName));

                try
                {
                    await smtp.SendMailAsync(mailMessage);
                }
                catch (SmtpException smtpEx)
                {
                    // Log or handle SMTP-specific errors
                    throw new Exception("Error sending email: " + smtpEx.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    throw new Exception("An error occurred while sending the email.", ex);
                }
            }
        }



    }
}
