using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers.Enums;


namespace Core.Models
{
    public class Store

    {
        Product[] Products;

        //- AddProduct( )
        public void AddProduct(params Product[] addproduct)
        {
            int oldlength = Products.Length;

            Array.Resize(ref Products, oldlength + addproduct.Length);
            for (int i = 0; i < addproduct.Length; i++)
            {
                Products[i] = addproduct[i];
            }
        }

        //- RemoveProductByNo() - no dəyər qəbul edir və bu dəyərli məhsul obyektini məhsullar siyahısından çıxarır
        public bool RemoveProductByNo(int no)
        {
            int indexToRemove = -1;

            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i] != null && Products[i].No == no)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1) return false;

            for (int i = indexToRemove; i < Products.Length - 1; i++)
            {
                Products[i] = Products[i + 1];
            }

            Array.Resize(ref Products, Products.Length - 1);
            return true;

        }
        //- GetProduct() -> nullable int No deyeri qebul edir eger hemin no'ya uyğun məhsul varsa geriyə qaytarır
        public Product GetProduct(int no)
        {
            Product getproduct = null;
            for (int i = 0; i < Products.Length; i++)
            {

                if (no == Products[i].No)
                {
                    getproduct = Products[i];
                    return getproduct;
                }
            }
            return getproduct;
        }
        //- FilterProductsByType() - növü dəyəri qəbul edir və edir. bu dəyərli məhsullardan əlavə array qaytarır

        public Product[] FilterProductsByType(Type type)
        {
            Product[] filteredProductsbytype = new Product[0];
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Types ==  type)
                {
                    Array.Resize(ref filteredProductsbytype, filteredProductsbytype.Length + 1);
                    filteredProductsbytype[filteredProductsbytype.Length - 1] = Products[i];
                }
            }
            return filteredProductsbytype;
        }

        public Product[] FilterProductByName(string name)
        {
            Product[] filteredProductsbyname = new Product[0];

            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name.ToLower() == name.ToLower())
                {
                    Array.Resize(ref filteredProductsbyname, filteredProductsbyname.Length + 1);
                    filteredProductsbyname[filteredProductsbyname.Length - 1] = Products[i];
                }
            }

            return filteredProductsbyname;
        }
    }
}