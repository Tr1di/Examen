using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace Login
{
    public class Tool
    {
        /// <summary>
        /// Уникальный идентификатор инструмента
        /// </summary>
        public virtual int ID { get; }
        
        /// <summary>
        /// Название инструмента
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Владелец инструмента
        /// </summary>
        /// <remarks>
        /// У инструмента может быть только один владелец
        /// </remarks>
        public virtual User Owner { get; set; }

        /// <summary>
        /// Описание инструмента
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Количество инструмента
        /// </summary>
        public virtual int Count { get; set; }

        /// <summary>
        /// Когда был куплен инстрмент
        /// </summary>
        public virtual DateTime Purchased { get; set; }

        public override string ToString()
        {
            // Краткая характеристика предмета состоит из его ID и дней с покупки
            // Количество дней со дня покупки определяется разностью между сегодня и днём покупки
            
            return $"{ID}, {(DateTime.Today - Purchased).Days}"; 
        }

        /// <summary>
        /// Все инструменты в базе данных
        /// </summary>
        /// <returns>Список всех инструментов в базе данных</returns>
        public static IList<Tool> GetAll()
        {
            // Select * From Tool
            return DataBase.Session.QueryOver<Tool>().List();
        }
    }

    internal class ToolMap : ClassMap<Tool>
    {
        public ToolMap()
        {
            // Для генерирования ID .GeneratedBy.Identity()
            Id(x => x.ID).GeneratedBy.Identity();

            Map(x => x.Name);
            // .Length() позваляет задать длинну строки
            // Описание подразумевает много текста, что указывается при помощи .Length(int.MaxValue)
            // По умолчанию длинна строки - 255 символов
            Map(x => x.Description).Length(int.MaxValue);
            Map(x => x.Purchased);

            // Всего один владелец у каждого инструмента
            References(x => x.Owner);
        }
    }
}
