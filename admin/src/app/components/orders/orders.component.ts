import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Bill } from '@app/models';
import { TranslateService } from '@ngx-translate/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

    constructor(private modalService: BsModalService,
        private toastr: ToastrService,
        private translate: TranslateService) {

    }
    twoFractionDigitNumberFormat: any;
    pageEvent: PageEvent;
    test: string;
    isLoadingResults: boolean;
    displayedColumns: string[] = ['no', 'name', 'weight', 'edit'];
    dataSource = new MatTableDataSource<Bill>();
    totalRow: number;
    pageIndex: number;
    pageSize: number;
    environment: any;
    txtSearch: string;
    public bsModalRef: BsModalRef;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    eventsSubject: Subject<void> = new Subject<void>();

    ngOnInit(): void {
        this.twoFractionDigitNumberFormat = new Intl.NumberFormat('vi-VN')
        this.pageEvent = {
            length: 0,
            pageIndex: 0,
            pageSize: 5,
            previousPageIndex: 0,
        }

        this.getDataPaging(this.pageEvent);
    }

    ngAfterViewInit() {
    }
    public getDataPaging(event: PageEvent) {

    }

    public pageEventHandle(event?: PageEvent) {
        console.log(event);
        this.getDataPaging(event);

        return event;
    }

    public edit(entity: Bill) {
        // this.itemModal = entity;
        // const initialState = {
        //     entity: this.itemModal,
        // };

        // this.bsModalRef = this.modalService.show(DiscountDetailComponent, {
        //     initialState: initialState,
        //     class: 'modal-lg',
        //     backdrop: 'static'
        // });

        // this.bsModalRef.content.saved.subscribe((e) => {
        //     console.log(e);
        //     this.bsModalRef.hide();
        // });
    }
    public onSearch() {
        console.log(this.txtSearch);

    }

}
