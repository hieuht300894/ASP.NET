using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using Server.Extension;
using System.Data.Entity.Migrations;
using System.Web.Mvc;

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

        public async override Task<ActionResult> GetAll()
        {
            try
            {
                db = new Model.aModel();

                List<eNhapHangNhaCungCapChiTiet> lstDetail = await db.eNhapHangNhaCungCapChiTiet.ToListAsync();
                var qDT =
                    from a in lstDetail
                    group a by a.IDNhapHangNhaCungCap into b
                    select new { IDNhapHangNhaCungCap = b.Key, NhapHangNhaCungCapChiTiets = b.ToList() };

                List<eNhapHangNhaCungCap> lstMaster = await db.eNhapHangNhaCungCap.ToListAsync();
                lstMaster.ForEach(a =>
                {
                    var b = qDT.FirstOrDefault(c => c.IDNhapHangNhaCungCap == a.KeyID);
                    if (b != null)
                    {
                        b.NhapHangNhaCungCapChiTiets.ForEach(c =>
                        {
                            a.eNhapHangNhaCungCapChiTiet.Add(c);
                        });
                    }
                });

                List<eNhapHangNhaCungCap> lstResult = new List<eNhapHangNhaCungCap>(lstMaster);
                return Ok(lstResult);
            }
            catch { return BadRequest(new List<eNhapHangNhaCungCap>()); }
        }

        public async override Task<ActionResult> GetByID(Object id)
        {
            try
            {
                db = new Model.aModel();
                eNhapHangNhaCungCap Item = await db.eNhapHangNhaCungCap.FindAsync(id);
                IEnumerable<eNhapHangNhaCungCapChiTiet> lstItemDetail = await db.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == Item.KeyID).ToListAsync();
                lstItemDetail.ToList().ForEach(x => Item.eNhapHangNhaCungCapChiTiet.Add(x));
                return Ok(Item);
            }
            catch { return BadRequest(new eNhapHangNhaCungCap()); }
        }

        public async override Task<ActionResult> AddEntries(eNhapHangNhaCungCap[] Items)
        {
            try
            {
                db = new Model.aModel();
                db.BeginTransaction();

                Items = Items ?? new eNhapHangNhaCungCap[] { };

                db.eNhapHangNhaCungCap.AddOrUpdate(Items);
                await db.SaveChangesAsync();

                Items.ToList().ForEach(x =>
                {
                    x.eNhapHangNhaCungCapChiTiet.ToList().ForEach(y =>
                    {
                        y.IDNhapHangNhaCungCap = x.KeyID;
                    });
                    db.eNhapHangNhaCungCapChiTiet.AddOrUpdate(x.eNhapHangNhaCungCapChiTiet.ToArray());
                });

                await CapNhatCongNo(Items);

                await db.SaveChangesAsync();
                db.CommitTransaction();

                return Ok(Items);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
            }
        }

        public async override Task<ActionResult> UpdateEntries(eNhapHangNhaCungCap[] Items)
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

                return Ok(Items);
            }
            catch (Exception ex)
            {
                db.RollbackTransaction();
                return BadRequest(ex);
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
                    db.eCongNoNhaCungCap.AddOrUpdate(congNo);
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
        async Task CapNhatTonKho(eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                foreach (eNhapHangNhaCungCapChiTiet itemDT in item.eNhapHangNhaCungCapChiTiet)
                {
                    eTonKho tonKho = await db.eTonKho.FirstOrDefaultAsync(x => x.IDSanPham == itemDT.IDSanPham && (x.HanSuDung.HasValue && itemDT.HanSuDung.HasValue && x.HanSuDung.Value.Date == itemDT.HanSuDung.Value.Date) || (!x.HanSuDung.HasValue && !itemDT.HanSuDung.HasValue) && x.IDKho == itemDT.IDKho);
                    if (tonKho == null)
                    {
                        tonKho = new eTonKho();
                        tonKho.KeyID = 0;
                        tonKho.IDSanPham = itemDT.IDSanPham;
                        tonKho.MaSanPham = itemDT.MaSanPham;
                        tonKho.TenSanPham = itemDT.TenSanPham;
                        tonKho.HanSuDung = itemDT.HanSuDung;
                    }
                }
            }
        }
    }
}