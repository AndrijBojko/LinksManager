using System.Collections.Generic;
using LinksManager.Entities;


namespace LinksManager.Services
{
    public interface ILinkServices
    {
        Link GetLinkById(int productId);
        IEnumerable<Link> GetAllLinks();
        void CreateLink(Link linkToCreate);
        void UpdateLink(Link linkToUpdate);
        void DeleteLink(int linkId);
    }
}
