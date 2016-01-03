using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.DataModels;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Repositories
{
    public class WeatherRepository : WeatherRepositoryBase
    {
        private readonly WeatherForcastDbContext _context = new WeatherForcastDbContext();
        protected override IQueryable<Weather> QueryWeathers()
        {
            return _context.Weather.AsQueryable();
        }

        public override void AddWeather(Weather weather)
        {
            _context.Weather.Add(weather);
        }
        
        public override void UpdateWeather(Weather weather)
        {
            _context.Entry(weather).State = EntityState.Modified;
        }

        public override void DeleteWeather(int id)
        {
            var weather = _context.Weather.Find(id);
            _context.Weather.Remove(weather);
        }

        public override void AddLocation(Location location)
        {
            _context.Locations.Add(location);
        }

        public override void UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
        }

        public override void DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            _context.Locations.Remove(location);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

        protected override IQueryable<Location> QueryLocations()
        {
            return _context.Locations.AsQueryable();
        }
    }


    //public class WeatherRepository : WeatherRepositoryBase
    //{
    //    private readonly WeatherAppEntities _context = new WeatherAppEntities();

    //    protected override IQueryable<Forcast> QueryForcasts()
    //    {
    //        return _context.Forcasts.AsQueryable();
    //    }

    //    public override void AddForcast(Forcast forcast)
    //    {
    //        _context.Forcasts.Add(forcast);
    //    }

    //    public override void UpdateForcast(Forcast forcast)
    //    {
    //        _context.Entry(forcast).State = EntityState.Modified;
    //    }

    //    public override void DeleteForcast(int id)
    //    {
    //        var forcast = _context.Forcasts.Find(id);
    //        _context.Forcasts.Remove(forcast);
    //    }

    //    public override void AddGeoLocation(GeoLocation geoLocation)
    //    {
    //        _context.GeoLocations.Add(geoLocation);
    //    }

    //    public override void UpdateGeoLocation(GeoLocation geoLocation)
    //    {
    //        _context.Entry(geoLocation).State = EntityState.Modified;
    //    }

    //    public override void DeleteGeoLocation(int id)
    //    {
    //        var geoLocation = _context.GeoLocations.Find(id);
    //        _context.GeoLocations.Remove(geoLocation);
    //    }

    //    public override void Save()
    //    {
    //        try
    //        {
    //            _context.SaveChanges();
    //        }
    //        //catch (DbUpdateConcurrencyException ex)
    //        //{
    //        //    throw new ApplicationException("Error while saving to database");
    //        //}

    //        //catch (EntitySqlException ex)
    //        //{

    //        //}
    //        //catch (SqlException ex)
    //        //{
                
    //        //}
    //        catch (Exception ex)
    //        {

    //        }

    //    }

    //    protected override IQueryable<GeoLocation> QueryGeoLocations()
    //    {
    //        return _context.GeoLocations.AsQueryable();
    //    }


    //}
}
