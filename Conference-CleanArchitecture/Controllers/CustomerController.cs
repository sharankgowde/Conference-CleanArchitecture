using CustomerApp.Core.Interfaces;
using CustomerApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conference_CleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
       
     
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomLogger _customLogger;
        private readonly IConfigDetails _configDetails;

        // Constructor
        public CustomerController(ICustomerRepository customerRepository, ICustomLogger customLogger, IConfigDetails configDetails)
            {
            _customerRepository = customerRepository;
            _customLogger = customLogger;
            _configDetails = configDetails;
        }

        // Action to add a customer
        [HttpPost]
        async Task<ActionResult> AddCustomer(Customer customer)
            {
            var configdetails = await _configDetails.GetCongDetails();

            var result = await   _customerRepository.AddCustomer(customer);

            await _customLogger.LogInformation(configdetails, "Customer added successfully.");

            return Ok();
            }


        // Action to get customer details by ID
        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetCustomerDetails()
            {

            IEnumerable<ConfigDetails> configdetails = null;

            try
            {

           

             configdetails = await _configDetails.GetCongDetails();     

            var customer = await _customerRepository.GetCustomerDetails(configdetails);

            await _customLogger.LogInformation(configdetails, $"{DateTime.Now}: Customer data read successfully.");

            if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
          

             }
            catch (Exception ex)
            {
              await  _customLogger.LogError(configdetails, ex.Message, ex);

                return BadRequest(ex.Message);
            }
        }


    }
}
