import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Discount } from '../../../models';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
    selector: 'app-discount',
    templateUrl: './discount.component.html',
    styleUrls: ['./discount.component.scss']
})
export class DiscountComponent implements OnInit, AfterViewInit {

    dataSource: MatTableDataSource<Discount>;
    constructor(private modalService: NgbModal, private toastr: ToastrService) { }
    public discounts: Discount[] = [
        { id: 1, fromDate: null, toDate: null, maxDiscountPrice: 100000, percentDiscount: 10 },
        { id: 2, fromDate: null, toDate: null, maxDiscountPrice: 1000, percentDiscount: 10 },
        { id: 3, fromDate: null, toDate: null, maxDiscountPrice: 1000, percentDiscount: 20 },
    ]
    displayedColumns: string[] = ['id'];
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;
    ngOnInit() {

        this.dataSource = new MatTableDataSource(this.discounts);
        this.dataSource.sort = this.sort;
    }

    ngAfterViewInit() {
    }

    edit(content: any, obj: any = null) {
        this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
            this.toastr.info("ssss");
        }, (reason) => this.toastr.error(reason));
    }
}
