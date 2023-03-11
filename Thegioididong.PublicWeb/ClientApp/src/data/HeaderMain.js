const HeaderMain_LogoDienThoai = require("../assets/Images/HeaderMain/icon-dien-thoai.png")
const HeaderMain_LogoLaptop = require("../assets/Images/HeaderMain/icon-laptop.png")
const HeaderMain_LogoTablet = require("../assets/Images/HeaderMain/icon-tablet.png")
const HeaderMain_LogoPhuKien = require("../assets/Images/HeaderMain/icon-phu-kien.png")
const HeaderMain_LogoSmartWatch = require("../assets/Images/HeaderMain/icon-smartwatch.png")
const HeaderMain_LogoWatch = require("../assets/Images/HeaderMain/icon-watch.png")
const HeaderMain_LogoPhone = require("../assets/Images/HeaderMain/icon-phone.png")
const HeaderMain_LogoPC = require("../assets/Images/HeaderMain/logo-pc.png")

const HeaderMain = [
    {
        id: 1,
        name: "Điện thoại",
        icon: HeaderMain_LogoDienThoai,
        listProductCategoryChild: null,
        listProductCategoryGroup: null,
    },
    {
        id: 2,
        name: "Laptop",
        description: null,
        icon: HeaderMain_LogoLaptop,
        listProductCategoryChild: null,
        listProductCategoryGroup: null,
    },
    {
        id: 3,
        name: "Tablet",
        description: null,
        icon: HeaderMain_LogoTablet,
        listProductCategoryChild: null,
        listProductCategoryGroup: null,
    },
    {
        id: 4,
        name: "Phụ kiện",
        description: null,
        icon: HeaderMain_LogoPhuKien,
        listProductCategoryChild: null,
        listProductCategoryGroup: [
            {
                id: 1,
                name: "Phụ kiện di động",
                listCategory: [
                    {
                        id: 11,
                        name: "Sạc dự phòng",
                    },
                    {
                        id: 12,
                        name: "Sạc, cáp",
                    },
                    {
                        id: 13,
                        name: "Ốp lưng điện thoại",
                    },
                    {
                        id: 14,
                        name: "Ốp lưng máy tín bảng",
                    },
                    {
                        id: 15,
                        name: "Miến dán màn hình",
                    },
                    {
                        id: 16,
                        name: "Gậy chụp ảnh, Gimbal",
                    },
                    {
                        id: 17,
                        name: "Giá đỡ điện thoại",
                    },
                    {
                        id: 18,
                        name: "Đế, móc điện thoại",
                    },
                    {
                        id: 19,
                        name: "Túi chống nước",
                    },
                    {
                        id: 20,
                        name: "Túi đựng AirPods",
                    },
                    {
                        id: 21,
                        name: "AirTag, Vỏ bảo vệ AirTag",
                    },
                    {
                        id: 22,
                        name: "Phụ kiện Tablet",
                    },
                    {
                        id: 22,
                        name: "Sạc dự phòng",
                    },
                ]
            },
            {
                id: 2,
                name: "Phụ kiện laptop",
                listCategory: [
                    {
                        id: 23,
                        name: "Sạc dự phòng",
                    },
                    {
                        id: 24,
                        name: "Thiết bị mạng",
                    },
                    {
                        id: 25,
                        name: "Balo, túi chống sốc",
                    },
                    {
                        id: 26,
                        name: "Giá đỡ laptop",
                    },
                    {
                        id: 27,
                        name: "Phần mềm",
                    },
                ]
            },
            {
                id: 3,
                name: "Thiết bị âm thanh",
                listCategory: [
                    {
                        id: 28,
                        name: "Tai nghe",
                    },
                    {
                        id: 29,
                        name: "Loa",
                    },
                    {
                        id: 30,
                        name: "Micro thu âm điện thoại",
                    },
                    {
                        id: 31,
                        name: "Micro",
                    },
                ]
            },
            {
                id: 4,
                name: "Thiết bị nhà thông minh",
                listCategory: [
                    {
                        id: 32,
                        name: "Khóa điện tử",
                    },
                    {
                        id: 33,
                        name: "Camera, webcam",
                    },
                    {
                        id: 34,
                        name: "Máy chiếu",
                    },
                    {
                        id: 35,
                        name: "TV Box",
                    },
                    {
                        id: 36,
                        name: "Ổ cắm, bóng đèn thông minh",
                    },
                ]
            },
            {
                id: 5,
                name: "Thiết bị lưu trữ",
                listCategory: [
                    {
                        id: 37,
                        name: "Ô cứng di động",
                    },
                    {
                        id: 38,
                        name: "Thẻ nhớ",
                    },
                    {
                        id: 39,
                        name: "USB",
                    },
                ]
            },
            {
                id: 6,
                name: "Thương hiệu hàng đầu",
                listCategory: [
                    {
                        id: 37,
                        name: "Apple",
                    },
                    {
                        id: 38,
                        name: "Samsung",
                    },
                    {
                        id: 39,
                        name: "Sony",
                    },
                    {
                        id: 40,
                        name: "JBL",
                    },
                    {
                        id: 41,
                        name: "Anker",
                    },
                ]
            },
            {
                id: 7,
                name: "Phụ kiện khác",
                listCategory: [
                    {
                        id: 42,
                        name: "Phụ kiện ô tô",
                    },
                    {
                        id: 43,
                        name: "Máy tính cầm tay",
                    },
                    {
                        id: 44,
                        name: "Quạt mini",
                    },
                    {
                        id: 45,
                        name: "Pin tiểu",
                    },
                ]
            },
        ],
    },
    {
        id: 5,
        name: "SmartWatch",
        description: null,
        icon: HeaderMain_LogoSmartWatch,
        listProductCategoryChild: null,
        listCategoryGroup: null,
    },
    {
        id: 6,
        name: "Đồng hồ",
        description: null,
        icon: HeaderMain_LogoWatch,
        listProductCategoryChild: null,
        listCategoryGroup: null,
    },
    {
        id: 7,
        name: "Máy cũ giá rẻ",
        description: null,
        icon: HeaderMain_LogoPhone,
        listProductCategoryChild: null,
        listCategoryGroup: null,
    },
    {
        id: 8,
        name: "PC, máy in",
        description: null,
        icon: HeaderMain_LogoPC,
        listProductCategoryChild: [
            {
                id: 46,
                name: "Máy in",
            },
            {
                id: 47,
                name: "Mực in",
            },
            {
                id: 48,
                name: "Màn hình máy tính",
            },
            {
                id: 49,
                name: "Màn tính để bàn",
            },
        ],
        listCategoryGroup: null,
    },
    {
        id: 9,
        name: "Sim, thẻ cào",
        description: null,
        icon: null,
        listProductCategoryChild: null,
        listCategoryGroup: null,
    },
    {
        id: 10,
        name: "Dịch vụ tiện ích",
        description: null,
        icon: null,
        listProductCategoryChild: null,
        listProductCategoryGroup: null,
    },
]

export default HeaderMain;