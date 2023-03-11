import React from 'react'
import "../../../assets/Styles/Client/Layouts/Footer.css"
import LogoWide from "../../../assets/Images/Logo/logo-wide.png"
import LogoFit from "../../../assets/Images/Logo/logo-fit.png"

const Footer = () => {
    return (
        <>
            <footer className="footer mt-4">
                <div className="container">
                    <div className="row row-cols-2 row-cols-lg-4 gy-4">
                        <div className="col">
                            <div className="footer__list-link">
                                <div className="footer__link">
                                    <span className="cursor-pointer">Tích điểm Quà tặng VIP</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Lịch sử mua hàng</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Cộng tác bán cùng TGDD</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Tìm hiểu về mua trả góp</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Chính sách bảo hành</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Chính sách đổi trả</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Giao hàng và thanh toán</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Hướng dẫn mua online</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Bán hàng doanh nghiệp</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Phiếu mua hàng</span>
                                </div>
                            </div>
                        </div>
                        <div className="col">
                            <div className="footer__list-link">
                                <div className="footer__link">
                                    <span className="cursor-pointer">In hóa đơn điện tử</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Quy chế hoạt động</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Nội quy cửa hàng</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Chất lượng phục vụ</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Cảnh báo giả mạo</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Chính sách sản phẩm Apple</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Giới thiệu công ty</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Tuyển dụng</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Gửi góp ý, khiếu nại</span>
                                </div>

                                <div className="footer__link">
                                    <span className="cursor-pointer">Tìm siêu thị</span>
                                </div>
                            </div>
                        </div>
                        <div className="col">
                            <div className="footer__link">
                                <span><b>Tổng đài hỗ trợ</b> (Miễn phí gọi)</span>
                            </div>

                            <div className="footer__link">
                                <span><b>Gọi mua: </b> <a className="text-primary" href="tel:18001060">1800.1060</a> (7:30 - 22:00)</span>
                            </div>

                            <div className="footer__link">
                                <span><b>Kỹ thuật: </b> <a className="text-primary" href="tel:18001060">1800.1763</a> (7:30 - 22:00)</span>
                            </div>

                            <div className="footer__link">
                                <span><b>Khiếu nại: </b> <a className="text-primary" href="tel:18001060">1800.1062</a> (7:30 - 22:00)</span>
                            </div>

                            <div className="footer__link">
                                <span><b>Bảo hành: </b> <a className="text-primary" href="tel:18001060">1800.1064</a> (7:30 - 22:00)</span>
                            </div>
                        </div>
                        <div className="col">
                            <div className="footer__social d-flex flex-column cursor-pointer">
                                <img src={LogoWide} className="img-fluid" alt='logo wide' />
                                <img src={LogoFit} className="img-fluid w-50" alt='="logo fit' />
                            </div>
                        </div>
                    </div>
                </div>
            </footer>

            <div className="copyright text-center">
                Copyright ©2023 Bản quyền thuộc về Khoa CNTT Trường Đại học Sư Phạm Kỹ Thuật Hưng Yên
            </div>
        </>
    )
}

export default Footer