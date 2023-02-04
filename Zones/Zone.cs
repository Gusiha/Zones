using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO Как сделать ЕДИНЫЙ enum Purpose для мебели и зон (и нужно ли вообще этот enum) ?

namespace Zones
{
    internal class Zone
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Area { get; set; }

        // Максимальная длина и ширина среди набора мебели
        public int MaxLength { get; set; }
        public int MaxWidth { get; set; }


        public enum Purpose { 
        
            Work=0,
            Rest=1,
        }

        public Zone(List<Furniture> furnitures, int id )
        {
            
            Area = furnitures.Where(p => p.ZoneId == id).Select(p => p.Area).ToList().Sum();
            //TODO Дописать заполнение класса

        }

        public static List<Zone> InitializeZones(List<Furniture> furnitures)
        {
            List<Zone> list = new List<Zone>();
            List<Purpose> unique = new List<Purpose>();
            
            foreach (var item in furnitures)
            {
                unique.Add((Purpose)item.ZoneId);
            }

            unique = unique.Distinct().ToList();

            foreach (var item in unique)
            {
                Zone zone = new(furnitures, (int)item);
                list.Add(zone);
            }

            return list;
        }

    }

    internal class Furniture
    {
        protected int _id;
        protected int _row, _col; // _x2, _y2;
       
        public int fittingFactor { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public int Area { get; protected set; }

        public int ZoneId { get; set; }

        public enum Purpose
        {

            Work = 0,
            Rest = 1,
            // и тд
        }

    }


}
