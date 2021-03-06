import CourseTeacher from './CourseTeacher'

export default interface Course {
    Id: Number,
    Name: String,
    StartDate: Date,
    EndDate: Date,
    Teachers: CourseTeacher[]
}