import { TestBed } from '@angular/core/testing';

import { TrainingProfileService } from './training-profile.service';

describe('TrainingProfileService', () => {
  let service: TrainingProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainingProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
