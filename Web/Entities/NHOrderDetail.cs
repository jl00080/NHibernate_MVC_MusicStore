namespace MvcMusicStore.Entities
{
    public class NHOrderDetail : Entity
    {
        //public virtual int OrderDetailId { get; private set; }
        public virtual int OrderId { get; set; }
        public virtual int AlbumId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }

        public virtual NHAlbum Album { get; set; }
        public virtual NHOrder Order { get; set; }
    }
}
