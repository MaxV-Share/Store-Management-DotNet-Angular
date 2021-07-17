import { Base } from "../bases/base";
import { BillDetail } from "./bill-detail";

export class Bill  extends Base {
    customerPhoneNumber?: string;
    customerFullName?: string;
    customerAddress?: string;
    userPaymentId?: string;
    userPaymentUserName?: string;
    totalPrice: number;
    discountPrice: number = 0;
    paymentAmount?: number;
    createAt?: Date;
    billDetails: BillDetail[]
}
