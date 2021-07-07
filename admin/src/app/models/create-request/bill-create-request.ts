import { BillDetailCreateRequest } from "./bill-detail-create-request";

export class BillCreateRequest {
    constructor(){
        this.discountPrice = 0;
        this.totalPrice = 0;
        this.paymentAmount = 0;
    }
    customerPhoneNumber?: string;
    userPaymentId?: string;
    userPaymentUserName?: string;
    totalPrice: number;
    discountPrice?: number;
    paymentAmount?: number;
    billDetails: BillDetailCreateRequest[]
}
