import { Component, OnInit } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  announcements: Announcement[] = [];
  selectedCategory: Category;
  title: any;
  filteredAnnouncements: Announcement[];

  constructor(private announcementService: AnnouncementService) {}
  ngOnInit(): void {
    this.announcementService.serviceCall();
    this.announcementService.getAnnouncements().subscribe((announcement) => {
      this.announcements = announcement;
      this.filteredAnnouncements = this.announcements;
    });
  }
  FilterAnnouncementsByCategory(category: Category): void {
    if (category == null) {
      this.announcementService.getAnnouncements().subscribe((announcement) => {
        this.announcements = announcement;
        this.filteredAnnouncements = this.announcements;
      });
    } else {
      this.announcementService
        .getAnnouncementByCategoryId(category.id)
        .subscribe((announcement) => {
          this.announcements = announcement;
          this.filteredAnnouncements = this.announcements;
        });
    }
  }
}
