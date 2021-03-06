import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators'
import Course from '../../models/Courses/Course'
import { getCoursesAsync } from '../../api/GraderApi/Controllers/Course'
import { nameof } from '../../utils/Extensions'

@Module({ name: 'coursesModule' })
export default class CoursesModule extends VuexModule {
    courses: Course[] = []

    @Action
    async GetCoursesAsync() {
        await this.context.dispatch('ShowLoadingAsync', true);

        try {
            const response = await getCoursesAsync();
            const courses = response.data.value.map((c: any) => {
                const course: Course = {
                    Id: c.Id,
                    Name: c.Name,
                    StartDate: c.StartDate,
                    EndDate: c.EndDate,
                    Teachers: c.Teachers.map((t: any) => `${t.FirstName} ${t.LastName}`).join(", ")
                }

                return course;
            });

            this.context.commit(nameof<CoursesModule>("StoreCourses"), courses);
        }
        catch (e) {
            await this.context.dispatch('ShowErrorAsync', e.data.Error);
            console.log(`Validation error ${e}`);
        }
        finally {
            await this.context.dispatch('ShowLoadingAsync', false);
        }
    }

    @Mutation
    StoreCourses(courses: Course[]) {
        this.courses = courses;
    }
}