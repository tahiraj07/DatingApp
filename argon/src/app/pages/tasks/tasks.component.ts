import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModalConfig, NgbModal ,ModalDismissReasons, NgbDateStruct} from '@ng-bootstrap/ng-bootstrap';
import { Task } from 'src/app/_models/task'; 
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
@Component({
  selector: 'app-tasks',  
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  @Input() createdById:number;
  @Input() task: Task;
  tasks: Task[];
  taskForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  constructor(public userService: UserService,private authService: AuthService,private router:Router, private alertify: AlertifyService,
    config: NgbModalConfig, private modalService: NgbModal, private fb: FormBuilder) {
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;}
    closeResult = '';
    ngOnInit(): void {
      this.bsConfig = {
      containerClass: 'theme-red'
    },
      this.userService.getTask(this.authService.decodedToken.nameid);
    }
  
    populateForm(selectedRecord: Task) {
      this.userService.formData = Object.assign({}, selectedRecord);
    }
    
    onDelete(id: number) {
      if (confirm('Are you sure to delete this record?')) {
        this.userService.deletePaymentDetail(id, this.authService.decodedToken.nameid)
          .subscribe(
            res => {
              this.userService.getTask(this.authService.decodedToken.nameid);
              console.log("Deleted successfully", 'Payment Detail Register');
            },
            err => { console.log(err) }
          )
      }
    }
    editTask(id: number) {
      
    }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }


  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  createRegisterForm() {
    this.taskForm = this.fb.group({ 
      taskDetail: [''], 
      taskName: [''],
      assigned: [''],
      status: [''],
      notify: [''],
      dueTo: [''],
      createdDate: [''],
      notes: [''],
      toDo: [''],
      comment: ['']

    });
  }
  
  addTask(){ 
     
    this.userService.addtask(this.authService.decodedToken.nameid,this.task).subscribe(() => 
    {
      
      this.alertify.success('Task added!');
      this.router.navigate(['/dashboard']);  
      this.modalService.dismissAll();
    },error => {
      console.log(error);
    }
    );
  }

  
}
