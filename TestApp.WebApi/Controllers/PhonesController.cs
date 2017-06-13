using System;
using System.Web.Http;
using TestApp.Models.Phones;
using TestApp.Operations.Abstraction;

namespace TestApp.WebApi.Controllers
{
    [RoutePrefix("phones")]
    public class PhonesController : ApiControllerBase
    {
        private readonly IPhonesOperations _phonesOperations;

        public PhonesController(IPhonesOperations oper) : base()
        {
            _phonesOperations = oper;
        }

        [HttpGet]
        [Route("all/{sort?}")]
        public IHttpActionResult GetAll(int? sort)
        {
            return Ok(_phonesOperations.GetAll(sort));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_phonesOperations.Get(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post(PhonePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _phonesOperations.Post(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult Edit(PhoneEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _phonesOperations.Edit(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _phonesOperations.Delete(id);
            return Ok();
        }
    }
}
