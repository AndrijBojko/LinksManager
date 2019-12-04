using System;
using System.Collections.Generic;
using System.Linq;
using LinksManager.DAL.UnitOfWork;
using LinksManager.Entities;


namespace LinksManager.Services
{
    public class LinkServices :ILinkServices
    {
        private readonly UnitOfWork _unitOfWork;


        public LinkServices()
        {
            _unitOfWork = new UnitOfWork();
        }


        public Link GetLinkById(int linkId)
        {
            var link = _unitOfWork.LinkRepository.GetById(linkId);

            return link;
        }

        public IEnumerable<Link> GetAllLinks()
        {
            var links = _unitOfWork.LinkRepository.GetAll().ToList();

            return links;
        }

        public void CreateLink(Link linkToAdd)
        {
            _unitOfWork.LinkRepository.Insert(linkToAdd);
            _unitOfWork.Save();       
        }

    public void UpdateLink(Link linkToUpdate)
    {
        if (linkToUpdate == null)
        {
            throw new ArgumentException("Trying to update with null reference link entity");
        }

        _unitOfWork.LinkRepository.Update(linkToUpdate);
        _unitOfWork.Save();
    }


        public void DeleteLink(int linkId)
        {
            _unitOfWork.LinkRepository.Delete(linkId);
            _unitOfWork.Save();
        }
    }
}
