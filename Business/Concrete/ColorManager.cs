using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        //CONSTRUCTOR
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        //ADD
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            // we used Aspect instead of kValidationTool.Validate(new ColorValidator(), color);
            _colorDal.Add(color);
            return new Result(true, Messages.ColorAdded);
        }
        //DELETE
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, Messages.ColorDeleted);
        }
        //UPDATE
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.ColorUpdated);
        }
        //GETALL
        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.ColorListed);
        }
        //GETBYID
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId));
        }
        //GET COLORS BY BRAND ID
        public IDataResult<Color> GetColorsByBrandId(int brandId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == brandId));
        }
    }
}