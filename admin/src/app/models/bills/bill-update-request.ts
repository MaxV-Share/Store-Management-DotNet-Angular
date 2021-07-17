import { BillDetail } from "./bill-detail";

export class BillUpdateRequest {
    customerPhoneNumber?: string;
    customerFullName?: string;
    customerAddress?: string;
    userPaymentId?: string;
    userPaymentUserName?: string;
    totalPrice: number;
    discountPrice?: number;
    paymentAmount?: number;
    billDetails: BillDetail[]
}
