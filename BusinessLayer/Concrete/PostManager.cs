using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PostManager : IPostService
    {

        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> TGetList()
        {
            return _postDal.GetList();
        }

        public Post TGetById(int id)// metot void türünde değil başına return ekle
        {
            return _postDal.GetById(id);
        }
        public void TDelete(Post t)
        {
            _postDal.Delete(t);
        }

        public void TInsert(Post t)
        {
            t.Date = DateTime.Now;
            _postDal.Insert(t);
        }

        public void TUpdate(Post t)
        {
            _postDal.Update(t);
        }
    }
}
