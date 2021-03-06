﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            foreach (var r in rentals)
            {
                if (r.ReturnDate == null || rental.RentDate < r.ReturnDate || rental.RentDate == r.RentDate)
                    return new ErrorResult( "Araba bosta degildir.");
            }
            
     
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.EntityAdded);

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.EntitiesListed);

        }


        public IDataResult<List<Rental>> GetRentalById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}
