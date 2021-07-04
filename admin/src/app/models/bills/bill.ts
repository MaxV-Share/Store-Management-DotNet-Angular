import { Base } from "../base";
import { BillDetail } from "./bill-detail";

export class Bill  extends Base {
    customerPhoneNumber?: string;
    userPaymentId?: string;
    userPaymentUserName?: string;
    totalPrice: number;
    discountPrice?: number;
    paymentAmount?: number;
    billDetails: BillDetail[]
}
