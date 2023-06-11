import { Component, Input } from '@angular/core';
import { AnnouncementService } from '../services/announcement.service';
import { Announcement } from '../announcement';
import { Router } from '@angular/router';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  styleUrls: ['./announcement.component.scss'],
})
export class AnnouncementComponent {
  @Input() announcement: Announcement;

  constructor(
    private announcementService: AnnouncementService,
    private router: Router
  ) {}

  async deleteAnnouncement(): Promise<void> {
    await this.announcementService.deleteAnnouncement(this.announcement.id);
    window.location.reload();
  }
}
