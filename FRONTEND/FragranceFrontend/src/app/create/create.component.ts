import { Component } from '@angular/core';
import { Createfragrance } from '../createfragrance';
import { DataService } from '../data.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: false,
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  newFragrance:Createfragrance = new Createfragrance()

  constructor(public data:DataService, private router:Router){}


  submit()
  {
    this.data.createFragrance(this.newFragrance).subscribe({
    next: frag => {
      console.log('Created:', frag);

      // itt van az új elem már hozzáadva a BehaviorSubject-hez
      this.router.navigate(['/list']); // csak itt navigálj
    },
    error: err => console.error(err)
  });
  }


}
