﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Repositories
{
    public abstract class WeatherRepositoryBase : IWeatherRepository
    {
        
        protected abstract IQueryable<Weather> QueryWeathers();

        public IEnumerable<Weather> GetWeathers()
        {
            return QueryWeathers().ToList();
        }

        public Weather GetWeather(int id)
        {
            return QueryWeathers().SingleOrDefault(f => f.WeatherId == id);
        }


        public abstract void AddWeather(Weather forcast);

        public abstract void UpdateWeather(Weather forcast);

        public abstract void DeleteWeather(int id);


        protected abstract IQueryable<Location> QueryLocations();

        public IEnumerable<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int id)
        {
            return QueryLocations().SingleOrDefault(i => i.LocationId == id);
        }

        public Location GetLocationByPlaceId(string placeId)
        {
            return QueryLocations().SingleOrDefault(l => l.PlaceCode == placeId);
        }

        public Location GetLocation(string location)
        {
            return QueryLocations().SingleOrDefault(l => l.LocationText == location);
        }

        public abstract void AddLocation(Location geoLocation);

        public abstract void UpdateLocation(Location geoLocation);

        public abstract void DeleteLocation(int id);
        public abstract void Save();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~WeatherRepositoryBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }




    //public abstract class WeatherRepositoryBase : IWeatherRepository
    //{
    //    protected abstract IQueryable<Forcast> QueryForcasts(); 

    //    public IEnumerable<Forcast> GetForcasts()
    //    {
    //        return QueryForcasts().ToList();
    //    }

    //    public Forcast GetForcast(int id)
    //    {
    //        return QueryForcasts().SingleOrDefault(f => f.ForcastId == id);
    //    }

    //    public abstract void AddForcast(Forcast forcast);

    //    public abstract void UpdateForcast(Forcast forcast);

    //    public abstract void DeleteForcast(int id);


    //    protected abstract IQueryable<GeoLocation> QueryGeoLocations();

    //    public IEnumerable<GeoLocation> GetGeoLocations()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public GeoLocation GetGeoLocation(int id)
    //    {
    //        return QueryGeoLocations().SingleOrDefault(i => i.GeoLocationId == id);
    //    }

    //    public GeoLocation GetGeoLocation(string location)
    //    {
    //        return QueryGeoLocations().SingleOrDefault(l => l.Location == location);
    //    }

    //    public abstract void AddGeoLocation(GeoLocation geoLocation);

    //    public abstract void UpdateGeoLocation(GeoLocation geoLocation);

    //    public abstract void DeleteGeoLocation(int id);
    //    public abstract void Save();

    //    #region IDisposable Support
    //    private bool disposedValue = false; // To detect redundant calls

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: dispose managed state (managed objects).
    //            }

    //            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    //            // TODO: set large fields to null.

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    //    // ~WeatherRepositoryBase() {
    //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //    //   Dispose(false);
    //    // }

    //    // This code added to correctly implement the disposable pattern.
    //    public void Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //        Dispose(true);
    //        // TODO: uncomment the following line if the finalizer is overridden above.
    //        // GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}
}
