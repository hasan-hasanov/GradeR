import { Module, VuexModule, Mutation, Action } from 'vuex-module-decorators'
import Grade from '../../models/Grades/Grade'
import { getGradesAsync } from '../../api/GraderApi/Controllers/Grade'
import { nameof } from '../../utils/Extensions'

@Module({ name: 'gradesModule' })
export default class GradesModule extends VuexModule {
    grades: Grade[] = []

    @Action
    async GetGradesAsync() {
        await this.context.dispatch('ShowLoadingAsync', true);

        try {
            const response = await getGradesAsync();
            const grades = response.data.value.map((g: any) => {
                const grade: Grade = {
                    Id: g.Id,
                    Grade: g.Grade,
                    Student: g.Student,
                    Teacher: g.Teacher,
                    Course: g.Course.Name
                }

                return grade;
            });

            this.context.commit(nameof<GradesModule>("StoreGrades"), grades);
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
    StoreGrades(grades: Grade[]) {
        this.grades = grades;
    }
}