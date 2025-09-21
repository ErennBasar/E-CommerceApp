import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LayoutModule} from './layout/layout-module';
import {ComponentsModule} from './components/components-module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LayoutModule, //eğer ki bir modül başka bir modülü benimseyecekse import edilmesi lazım
    ComponentsModule
  ],
  exports: [
    LayoutModule
  ]
})
export class AdminModule { }
