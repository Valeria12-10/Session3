//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WareHouseLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЭлементыРасходнойНакладной
    {
        public int IDЭлементаНакладной { get; set; }
        public int IDНакладной { get; set; }
        public int IDТовара { get; set; }
        public int Количество { get; set; }
        public decimal Цена { get; set; }
    
        public virtual РасходныеНакладные РасходныеНакладные { get; set; }
        public virtual Товары Товары { get; set; }
    }
}
