using System;
using System.Collections.Generic;
using System.Linq;

namespace WareHouseLibrary
{
    public class Class1
    {
        private readonly WarehouseManagementEntities _context;

        public Class1()
        {
            _context = new WarehouseManagementEntities();
        }

        // Метод 1: Подсчет общего количества товаров на всех складах
        public int CalculateTotalQuantity()
        {
            return _context.Склады.Sum(s => s.Количество ?? 0);
        }

        // Перегрузка метода 1: Подсчет количества товаров на конкретном складе
        public int CalculateTotalQuantity(int warehouseID)
        {
            return _context.Склады
                .Where(s => s.IDСклада == warehouseID)
                .Sum(s => s.Количество ?? 0);
        }

        // Метод 2: Подсчет общей стоимости товаров на всех складах
        public decimal CalculateTotalValue()
        {
            return _context.Склады
                .Join(_context.Товары,
                    stock => stock.IDСклада,
                    product => product.IDТовара,
                    (stock, product) => new { stock.Количество, product.Цена })
                .Sum(x => (x.Количество ?? 0) * (x.Цена));
        }

        // Перегрузка метода 2: Подсчет стоимости товаров на конкретном складе
        public decimal CalculateTotalValue(int warehouseID)
        {
            return _context.Склады
                .Where(s => s.IDСклада == warehouseID)
                .Join(_context.Товары,
                    stock => stock.IDТовара,
                    product => product.IDТовара,
                    (stock, product) => new { stock.Количество, product.Цена })
                .Sum(x => (x.Количество ?? 0) * (x.Цена));
        }

        // Метод 3: Подсчет количества товаров по категориям на всех складах
        public Dictionary<string, int> CalculateQuantityByCategory()
        {
            return _context.Склады
                .Join(_context.Товары,
                    stock => stock.IDТовара,
                    product => product.IDТовара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество ?? 0));
        }

        // Перегрузка метода 3: Подсчет количества товаров по категориям на конкретном складе
        public Dictionary<string, int> CalculateQuantityByCategory(int warehouseID)
        {
            return _context.Склады
                .Where(s => s.IDСклада == warehouseID)
                .Join(_context.Товары,
                    stock => stock.IDТовара,
                    product => product.IDТовара,
                    (stock, product) => new { product.Категория, stock.Количество })
                .GroupBy(x => x.Категория)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Количество ?? 0));
        }
    }
}