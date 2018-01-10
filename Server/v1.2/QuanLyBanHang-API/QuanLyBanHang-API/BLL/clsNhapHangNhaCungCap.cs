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
using Server.Model;

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
            aModel db = new aModel();
            try
            {
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
            aModel db = new aModel();
            try
            {
                eNhapHangNhaCungCap Item = await db.eNhapHangNhaCungCap.FindAsync(id);
                IEnumerable<eNhapHangNhaCungCapChiTiet> lstItemDetail = await db.eNhapHangNhaCungCapChiTiet.Where(x => x.IDNhapHangNhaCungCap == Item.KeyID).ToListAsync();
                lstItemDetail.ToList().ForEach(x => Item.eNhapHangNhaCungCapChiTiet.Add(x));
                return Ok(Item);
            }
            catch { return BadRequest(new eNhapHangNhaCungCap()); }
        }

        public async override Task<ActionResult> AddEntries(eNhapHangNhaCungCap[] Items)
        {
            aModel db = new aModel();
            try
            {
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

                await CapNhatCongNo(db, Items);
                await CapNhatTonKho(db, Items);

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
            aModel db = new aModel();
            try
            {
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

                await CapNhatCongNo(db, Items);
                await CapNhatTonKho(db, Items);

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

        async Task CapNhatCongNo(aModel db, eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                eCongNoNhaCungCap congNo = await db.eCongNoNhaCungCap.FirstOrDefaultAsync(x => x.IsNhapHang && x.IDMaster == item.KeyID);
                if (congNo == null)
                {
                    congNo = new eCongNoNhaCungCap();
                    congNo.IDNhaCungCap = item.IDNhaCungCap;
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
                congNo.MaNhaCungCap = item.MaNhaCungCap;
                congNo.TenNhaCungCap = item.TenNhaCungCap;
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
        async Task CapNhatTonKho(aModel db, eNhapHangNhaCungCap[] Items)
        {
            foreach (eNhapHangNhaCungCap item in Items)
            {
                foreach (eNhapHangNhaCungCapChiTiet itemDT in item.eNhapHangNhaCungCapChiTiet)
                {
                    eTonKho tonKho = await db.eTonKho.FirstOrDefaultAsync(x => x.IsNhapHang && x.IDMaster == item.KeyID && x.IDDetail == itemDT.KeyID);

                    if (tonKho == null)
                    {
                        tonKho = new eTonKho();
                        tonKho.IDSanPham = itemDT.IDSanPham;
                        tonKho.IDNhomSanPham = itemDT.IDNhomSanPham;
                        tonKho.IDDonViTinh = itemDT.IDDonViTinh;
                        tonKho.IDMaster = item.KeyID;
                        tonKho.IDDetail = itemDT.KeyID;
                        tonKho.NguoiTao = item.NguoiTao;
                        tonKho.MaNguoiTao = item.MaNguoiTao;
                        tonKho.TenNguoiTao = item.TenNguoiTao;
                        tonKho.NgayTao = item.NgayTao;
                        tonKho.IsNhapHang = true;
                        db.eTonKho.AddOrUpdate(tonKho);
                    }
                    else
                    {
                        tonKho.NguoiCapNhat = item.NguoiCapNhat;
                        tonKho.MaNguoiCapNhat = item.MaNguoiCapNhat;
                        tonKho.TenNguoiCapNhat = item.TenNguoiCapNhat;
                        tonKho.NgayCapNhat = item.NgayCapNhat;
                    }
                    tonKho.Ngay = item.NgayNhap;
                    tonKho.MaSanPham = itemDT.MaSanPham;
                    tonKho.TenSanPham = itemDT.TenSanPham;
                    tonKho.MaNhomSanPham = itemDT.MaNhomSanPham;
                    tonKho.TenNhomSanPham = itemDT.TenNhomSanPham;
                    tonKho.MaDonViTinh = itemDT.MaDonViTinh;
                    tonKho.TenDonViTinh = itemDT.TenDonViTinh;
                    tonKho.HanSuDung = itemDT.HanSuDung;
                    tonKho.SoLuongSi = itemDT.SoLuongSi;
                    tonKho.SoLuongLe = itemDT.SoLuongLe;
                    tonKho.SoLuong = itemDT.SoLuong;
                }
            }
        }
    }
}