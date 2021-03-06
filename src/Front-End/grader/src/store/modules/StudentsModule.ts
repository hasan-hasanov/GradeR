import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators'
import Student from '../../models/Students/Student'
import { getStudentsAsync } from '../../api/GraderApi/Controllers/Student'
import { nameof } from '../../utils/Extensions'

@Module({ name: 'studentsModule' })
export default class StudentsModule extends VuexModule {
    students: Student[] = []

    @Action
    async GetStudentsAsync() {
        await this.context.dispatch('ShowLoadingAsync', true);

        try {
            const response = await getStudentsAsync();
            const students = response.data.value.map((s: any) => {
                const student: Student = {
                    Id: s.Id,
                    Name: `${s.FirstName} ${s.LastName}`,
                    BirthDate: s.BirthDate,
                    Courses: s.Courses.map((c: any) => c.Name).join(", ")
                }

                return student;
            });

            this.context.commit(nameof<StudentsModule>("StoreStudents"), students);
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
    StoreStudents(students: Student[]) {
        this.students = students;
    }
}