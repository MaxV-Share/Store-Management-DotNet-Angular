// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { HttpHeaders } from "@angular/common/http";
import { Lang } from "./lang";

export const environment = {
    production: false,
    apiUrl: `http://localhost:5000`,
    fileUrl: `http://localhost:5000/Files`,
    _sharedHeaders: new HttpHeaders({ 'Content-Type': 'application/json' })

};
export const langs: Lang[] = [
    {
        id: "vi",
        name: "Tiếng Việt"
    },
    {
        id: "en",
        name: "English"
    },
]
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
