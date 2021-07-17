// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { HttpHeaders, HttpParams } from "@angular/common/http";
import { Lang } from "./lang";

export const ENVIRONMENT = {
    production: false,
    apiUrl: `http://localhost:5000`,
    fileUrl: `http://localhost:5000/Files/`,

};
export const LANGS: Lang[] = [
    {
        id: "vi",
        name: "Tiếng Việt"
    },
    {
        id: "en",
        name: "English"
    },
]
export const OPTIONS_DEFAULT: {
    headers?: HttpHeaders | {
        [header: string]: string | string[];
    };
    observe: 'events';
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
} = {
    observe: 'events'
}
export const OPTIONS_JSON : {
    headers?: HttpHeaders | {
        [header: string]: string | string[];
    };
    observe: 'events';
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: 'json';
    withCredentials?: boolean;
} = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    observe: 'events',
    responseType: 'json',
}

export const OPTIONS_TEXT: {
    headers?: HttpHeaders | {
        [header: string]: string | string[];
    };
    observe: 'events';
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType: 'text';
    withCredentials?: boolean;
} = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    observe: 'events',
    responseType: 'text',
}
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
