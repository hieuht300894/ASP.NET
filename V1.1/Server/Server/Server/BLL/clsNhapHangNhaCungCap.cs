using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using Server.Extension;
using System.Data.Entity.Migrations;

namespace Server.BLL
{
    public class clsNhapHangNhaCungCap : clsFunction<eNhapHangNhaCungCap>
    {
        #region Contructor
        protected clsNhapHangNhaCungCap() { }
        public new static clsNhapHangNhaCungCap Instance
        {
            get { return new clsNhapHangNhaCungCap(); }
        }
        #endregion

        public override async Task<IEnumerable<eNhapHangNhaCungCap>> GetAll()
        {
            try
            {
                db = new Model.aModel();
                IEnumerable<eNhapHangNhaCungCap> lstMaster = await db.eNhapHangNhaCungCap.ToListAsync();
                IEnumerable<eNhapHangNhaCungCapChiTiet> lstDetail = await db.eNhapHangNhaCungCapChiTiet.ToListAsync();

                var q1 =
                    from a in lstDetail
                    group a by a.IDNhapHangNhaCungCap into g
                    select new { Key = g.Key, Value = g.ToList() };
                var q2 =
                    from a in lstMaster
                    join b in q1
                    on a.KeyID equals b.Key
                    select new { Master = a, Detail = b.Value };
                q2.ToList().ForEach(x =>
                {
                    x.Detail.ForEach(y =>
                    {
                        x.Master.eNhapHangNhaCungCapChiTiet.Add(y);
                    });
                });
                var q3 =
                    from a in q2
                    select a.Master;

                List<eNhapHangNhaCungCap> lstResult = new List<eNhapHangNhaCungCap>(q3);
                return lstResult;
            }
            catch { return new List<eNhapHangNhaCungCap>(); }
        }

        public async override Task<eNhapHangNhaCungCap> GetByID(Object id)
        {
            try
            {
                db = new Model.aModel();
                eNhapHangNhaCungCap Item = await db.eNhapHangNhaCungCap.FindAsync(id);
                IEnumerable<eNhapHangNhaCungCapChiTiet> lstItemDetail = await db.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == Item.KeyID).ToListAsync();
                lstItemDetail.ToList().ForEach(x => Item.eNhapHangNhaCungCapChiTiet.Add(x));
                return Item;
            }
            catch { return new eNhapHangNhaCungCap(); }
        }

        public async override Task<Exception> AddEntries(eNhapHangNhaCungCap[] Items)
        {
            try
            {
                db = new Model.aModel();
                db.BeginTransaction();

                Items = Items ?? new eNhapHangNhaCungCap[] { };

                db.eNhapHangNhaCungCap.AddRange(Items);
                await db.SaveChangesAsync();

                Items.ToList().ForEach(x =>
               {
                   x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
                   {
                       y.IDNhapHangNhaCungCap = x.KeyID;
                   });
                   db.eNhapHangNhaCungCapChiTiet.AddRange(x.eNhapHangNhaCungCapChiTiet.ToArray());
               });

                await CapNhatCongNo(Items);

                await db.SaveChangesAsync();
                db.CommitTransaction();

                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        public async override Task<Exception> UpdateEntries(eNhapHangNhaCungCap[] Items)
        {
            try
            {
                db = new Model.aModel();
                db.BeginTransaction();

                db.eNhapHangNhaCungCap.AddOrUpdate(Items);

                Items.ToList().ForEach(async x =>
                {
                    IEnumerable<eNhapHangNhaCungCapChiTiet> lstDetail = await db.eNhapHangNhaCungCapChiTiet.Where(y => y.IDNhapHangNhaCungCap == x.KeyID).ToListAsync();
                    lstDetail.ToList().ForEach(y =>
                    {
                        eNhapHangNhaCungCapChiTiet obj = x.eNhapHangNhaCungCapChiTiet.FirstOrDefault(z => z.KeyID == y.KeyID);
                        if (obj == null)
                            db.eNhapHangNhaCungCapChiTiet.Remove(y);
                        else
                            db.Entry(y).CurrentValues.SetValues(obj);

                    });
                    x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
                    {
                        if (y.KeyID <= 0)
                        {
                            y.IDNhapHangNhaCungCap = x.KeyID;
                            db.eNhapHangNhaCungCapChiTiet.Add(y);
                        }
                    });
                });

                await CapNhatCongNo(Items);

                await db.SaveChangesAsync();
                db.CommitTransaction();

                return null;
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return ex;
            }
        }

        async Task CapNhatCongNo(eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                eCongNoNhaCungCap congNo = await db.eCongNoNhaCungCap.FirstOrDefaultAsync(x => x.IsNhapHang && x.IDMaster == item.KeyID);
                if (congNo == null)
                {
                    congNo = new eCongNoNhaCungCap();
                    congNo.IDNhaCungCap = item.IDNhaCungCap;
                    congNo.MaNhaCungCap = item.MaNhaCungCap;
                    congNo.TenNhaCungCap = item.TenNhaCungCap;
                    congNo.IDMaster = item.KeyID;
                    congNo.NguoiTao = item.NguoiTao;
                    congNo.MaNguoiTao = item.MaNguoiTao;
                    congNo.TenNguoiTao = item.TenNguoiTao;
                    congNo.NgayTao = item.NgayTao;
                    congNo.IsNhapHang = true;
                    db.eCongNoNhaCungCap.Add(congNo);
                }
                else
                {
                    congNo.NguoiCapNhat = item.NguoiCapNhat;
                    congNo.MaNguoiCapNhat = item.MaNguoiCapNhat;
                    congNo.TenNguoiCapNhat = item.TenNguoiCapNhat;
                    congNo.NgayCapNhat = item.NgayCapNhat;
                }
                congNo.TrangThai = item.TrangThai;
                congNo.Ngay = item.NgayNhap;
                congNo.ThanhTien = item.ThanhTien;
                congNo.VAT = item.VAT;
                congNo.TienVAT = item.TienVAT;
                congNo.CK = item.ChietKhau;
                congNo.TienCK = item.TienChietKhau;
                congNo.TongTien = item.TongTien;
                congNo.NoCu = item.NoCu;
                congNo.ThanhToan = item.ThanhToan;
                congNo.ConLai = item.ConLai;
                congNo.GhiChu = item.GhiChu;
            }
        }
    }
}