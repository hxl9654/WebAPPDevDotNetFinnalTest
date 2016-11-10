using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BLL_Brand
{
    public void New(string BrandName, string ProductAddress)
    {
        Brand brand = new Brand();
        brand.BrandName = BrandName;
        brand.ProductAddress = ProductAddress;
        DAL_Brand BrandDAL = new DAL_Brand();
        BrandDAL.Insert(brand);
    }
    public Brand SelectOne(int BrandID)
    {
        Brand brand = new Brand();
        brand.BrandID = BrandID;
        DAL_Brand BrandDAL = new DAL_Brand();
        return BrandDAL.SelectOne(brand);
    }
    public List<Brand> SelectAll()
    {
        DAL_Brand BrandDAL = new DAL_Brand();
        return BrandDAL.SelectAll();
    }
    public void Delete(int BrandID)
    {
        Brand brand = new Brand();
        brand.BrandID = BrandID;
        DAL_Brand BrandDAL = new DAL_Brand();
        BrandDAL.Delete(brand);
    }
    public void Update(int BrandID, string BrandName, string ProductAddress)
    {
        Brand brand = new Brand();
        brand.BrandID = BrandID;
        brand.BrandName = BrandName;
        brand.ProductAddress = ProductAddress;
        DAL_Brand BrandDAL = new DAL_Brand();
        BrandDAL.Update(brand);
    }
}