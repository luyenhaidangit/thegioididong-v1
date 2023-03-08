import { MdPhoneIphone, MdOutlineFlashOn, MdVideogameAsset } from "react-icons/md";
import { BsDice5Fill } from "react-icons/bs";

const ServiceConversation = [
    {
        id: 1,
        image: <MdPhoneIphone size={"2.5rem"} color={"rgb(60,183,235)"} style={{ padding: "8px", borderRadius: "100%", backgroundColor: "rgb(200,231,252)", }} />,
        title: "Mua Mã thẻ cào",
        bold_description: "Giảm 3%",
        description: " cho mệnh giá từ 100.000 trở lên",
        style: {
            backgroundColor: "#dceeff",
        },
    },
    {
        id: 2,
        image: <MdOutlineFlashOn size={"2.5rem"} color={"rgb(252,155,5)"} style={{ padding: "8px", borderRadius: "100%", backgroundColor: "rgb(253,238,188)", }} />,
        title: "Dịch Vụ Đóng Tiền",
        bold_description: null,
        description: "Điện, Nước, Internet, Cước điện thoại trả sau",
        style: {
            backgroundColor: "#fef5cf",
        },
    },
    {
        id: 3,
        image: <MdVideogameAsset size={"2.5rem"} color={"rgb(255,85,73)"} style={{ padding: "8px", borderRadius: "100%", backgroundColor: "rgb(255,226,207)", }} />,
        title: "Mua thẻ game",
        bold_description: "Giảm 2%",
        description: " cho tất cả nhà mạng, áp dụng cho mệnh giá từ 300.000đ",
        style: {
            backgroundColor: "#ffefdb",
        },
    },
    {
        id: 4,
        image: <BsDice5Fill size={"2.4rem"} color={"rgb(99,223,83)"} style={{ padding: "8px", borderRadius: "100%", backgroundColor: "rgb(214,250,195)", }} />,
        title: "Office bản quyền",
        bold_description: null,
        description: "Mua Microsoft Office giá chỉ từ 990k",
        style: {
            backgroundColor: "#e1fecf",
        },
    }
]

export default ServiceConversation;