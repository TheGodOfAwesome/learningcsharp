using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using Remotion.Linq.Clauses;

namespace ToDoApplication.Extensions
{
    public static class ModelExtensions
    {
        public static Destination ToModel<Source, Destination>(this Source toDo)
        {
            var result = Activator.CreateInstance<Destination>();

            var props = typeof(Destination).GetProperties();

            foreach (var propertyInfo in props)
            {
                var valueProp = typeof(Source).GetProperties().FirstOrDefault(x => x.Name == propertyInfo.Name);

                var value = valueProp?.GetValue(toDo).ToString();

                if (propertyInfo.PropertyType == typeof(DateTime?) || propertyInfo.PropertyType == typeof(DateTime))
                {
                    if (DateTime.TryParse(value, out var date))
                    {
                        propertyInfo.SetValue(result, date);
                    }

                    continue;
                }

                if (propertyInfo.PropertyType == typeof(long))
                {
                    if (int.TryParse(value, out var longValue))
                    {
                        propertyInfo.SetValue(result, longValue);
                    }

                    continue;
                }

                if (propertyInfo.PropertyType == typeof(int?) || propertyInfo.PropertyType == typeof(int))
                {
                    if (int.TryParse(value, out var intValue))
                    {
                        propertyInfo.SetValue(result, intValue);
                    }

                    continue;
                }


                propertyInfo.SetValue(result, value);
            }


            return result;
        }

        public static Destination ToModelUsingMapper<Source, Destination>(this Source source)
        {
            return Mapper.Map<Source, Destination>(source);
        }

        public static Destination ToModelUsingMapper<Destination>(this object source)
        {
            return Mapper.Map<Destination>(source);
        }
    }
}