using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // class içinde ki metotların dışında tanımlarsak global değişken dir _ li tanımlarız.

        public InMemoryProductDal()
        {
            //Oracle , SQL Server, MongoDb  geliyomuş gibi simüle ettik
            _products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Tabak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=5000,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},

            };
        }


        public void Add(Product product)
        {
            _products.Add(product);// business katmanından gelen veriyi simule ettiğimiz veritabanına ekliyoruz
        }

        public void Delete(Product product)
        {
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p; // silinecek olanın referansını, referansız elemanımıza atıp silebiliyoruz.
            //    }
            //}


            //LINQ = language integrated query

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);// _products u tek tek dolaşmaya yarar. // singleordefault bir tane arar.
            // SingleOrDefault yerine First, FirstOrDefault da olur.
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;

        }


        public void Update(Product product)
        {
            //gönderdiğim ürün id'sine sahip ürünü liste de bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            //where içindeki koşula uyanları yeni bir listeye çevirip geri döndürür.
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }
    }
}
