using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;  // bir iş sınıfı başka sınıfları new lemez!!!!!!!!!! 

        public ProductManager(IProductDal productDal) // soyut sınıfın injeksiyonu yapılır çünkü yarın veritabanı alternatiflerimiz değişebilir
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // iş kodları
            // örneğin erişmeye yetkisi var mı

            return _productDal.GetAll();



            
        }
    }
}
