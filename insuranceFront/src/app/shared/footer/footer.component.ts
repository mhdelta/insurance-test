import { Component, HostBinding } from '@angular/core';
import { version } from '../../../../package.json';

@Component({
    moduleId: module.id,
    selector: 'footer-cmp',
    templateUrl: 'footer.component.html'
})

export class FooterComponent{
    public version: string = version;
    test : Date = new Date();
}
