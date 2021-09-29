import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CookieConsentService, FunctionService } from '@app/shared/services';
import { FunctionViewModel, HTTP_STATUS } from '@app/models';
import { HttpResponse } from '@angular/common/http';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
    isActive: boolean;
    collapsed: boolean;
    showMenu: string;
    pushRightClass: string;
    treeFunctions: FunctionViewModel[];

    @Output() collapsedEvent = new EventEmitter<boolean>();

    constructor(private translate: TranslateService,
        private functionService: FunctionService,
        public router: Router,
        private cookieConsentService: CookieConsentService) {
        this.router.events.subscribe((val) => {
            if (val instanceof NavigationEnd && window.innerWidth <= 992 && this.isToggled()) {
                this.toggleSidebar();
            }
        });
    }

    ngOnInit() {
        this.isActive = false;
        this.collapsed = false;
        this.showMenu = '';
        this.pushRightClass = 'push-right';
        this.loadFunction();
    }

    eventCalled() {
        this.isActive = !this.isActive;
    }

    addExpandClass(element: any) {
        if (element === this.showMenu) {
            this.showMenu = '0';
        } else {
            this.showMenu = element;
        }
    }

    toggleCollapsed() {
        this.collapsed = !this.collapsed;
        this.collapsedEvent.emit(this.collapsed);
    }

    isToggled(): boolean {
        const dom: Element = document.querySelector('body');
        return dom.classList.contains(this.pushRightClass);
    }

    toggleSidebar() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle(this.pushRightClass);
    }

    rltAndLtr() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle('rtl');
    }

    changeLang(language: string) {
        localStorage.setItem('lang',language)
        this.translate.use(language);
        window.location.reload();
    }

    onLoggedout() {
        this.cookieConsentService.deleteCookie('token');
    }
    loadFunction() {
        this.functionService.getTree().subscribe((res: HttpResponse<FunctionViewModel[]>) => {
            if(res.status === HTTP_STATUS.Ok) {
                this.treeFunctions = res.body;
                this.treeFunctions.forEach(e => e.hasChildren  = e.childrens?.length > 0)
                console.log(this.treeFunctions);
            }
        })
    }
}
