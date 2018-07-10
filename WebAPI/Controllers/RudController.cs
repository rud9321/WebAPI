using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Secure;

namespace WebAPI.Controllers
{
    public class RudController : ApiController
    {
        [HttpGet]
        [SecureAuthorize]
        public List<MsCodeModel> GetAll()
        {
            return MsCodeRepository.GetAll();
        }
        [HttpGet]
        public MsCodeModel Get(int id)
        {
            return MsCodeRepository.GetOne(id);
        }
        [HttpPost]
        public IHttpActionResult Post(MsCodeModel model)
        {
            MsCodeRepository.GetAll().Add(model);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }
        [HttpPut]
        public IHttpActionResult Put(int id, MsCodeModel model)
        {
            MsCodeRepository.UpdateData(id, model);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            MsCodeRepository.DeleteData(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
