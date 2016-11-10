using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BLL_Model
{
    public void New(int BrandID, string Color, string Info, string ModelName, string Picture)
    {
        Model model = new Model();
        model.BrandID = BrandID;
        model.Color = Color;
        model.Info = Info;
        model.ModelName = ModelName;
        model.Picture = Picture;
        DAL_Model ModelDAL = new DAL_Model();
        ModelDAL.Insert(model);
    }
    public Model SelectOne(int ModelID)
    {
        Model model = new Model();
        model.ModelID = ModelID;
        DAL_Model ModelDAL = new DAL_Model();
        return ModelDAL.SelectOne(model);
    }
    public List<Model> SelectByBrandID(int BrandID)
    {
        Model model = new Model();
        model.BrandID = BrandID;
        DAL_Model ModelDAL = new DAL_Model();
        return ModelDAL.SelectByBrandID(model);
    }
    public List<Model> SelectAll()
    {
        DAL_Model ModelDAL = new DAL_Model();
        return ModelDAL.SelectAll();
    }
    public void Delete(int ModelID)
    {
        Model model = new Model();
        model.ModelID = ModelID;
        DAL_Model ModelDAL = new DAL_Model();
        ModelDAL.Delete(model);
    }
    public void Update(int ModelID, int BrandID, string Color, string Info, string ModelName, string Picture)
    {
        Model model = new Model();
        model.ModelID = ModelID;
        model.BrandID = BrandID;
        model.Color = Color;
        model.Info = Info;
        model.ModelName = ModelName;
        model.Picture = Picture;
        DAL_Model ModelDAL = new DAL_Model();
        ModelDAL.Update(model);
    }
}