using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinksManager.Entities;
using LinksManager.Services;


namespace LinksManager.WEB.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkServices _linkServices;


        public LinksController()
        {
            _linkServices = new LinkServices();
        }


        // GET api/links
        public HttpResponseMessage Get()
        {
            var links = _linkServices.GetAllLinks();

            if (links != null)
                return Request.CreateResponse(HttpStatusCode.OK, links);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Links not found");
        }

        // GET api/links/5
        public HttpResponseMessage Get(int id)
        {
            var link = _linkServices.GetLinkById(id);
            if (link != null)
                return Request.CreateResponse(HttpStatusCode.OK, link);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No link found for this id");
        }

        // POST api/links
        public void Post([FromBody] Link linkToCreate)
        {
            _linkServices.CreateLink(linkToCreate);

        }

        // PUT api/links/
        public void Put([FromBody]Link linkToUpdate)
        {
            _linkServices.UpdateLink(linkToUpdate);
        }

        // DELETE api/links/5
        public void Delete(int id)
        {
            _linkServices.DeleteLink(id);
        }
    }
}
