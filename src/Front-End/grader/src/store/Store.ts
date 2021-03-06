import { createStore } from "vuex";
import CoursesModule from "./modules/CoursesModule";
import StudentsModule from "./modules/StudentsModule"
import GradesModule from "./modules/GradesModule"

export default createStore({
    state: {
        isLoading: false,
        error: "",
        successMessages: <String[]>[]
    },
    actions: {
        ShowLoadingAsync: async (context, payload) => {
            if (payload) {
                context.commit("SetError", "");
            }
            context.commit("SetLoading", payload);
        },
        AddSuccessMessageAsync: async (context, payload) => {
            context.commit("AddSuccess", payload);
            context.commit("SetError", "");
        },
        ShowErrorAsync: async (context, payload) => {
            context.commit("SetError", payload);
        },

        // These methods are called from global components
        // They are not meant to be public
        RemoveFirstSuccessMessageAsync: async (context) => {
            context.commit("RemoveSuccess");
            context.commit("SetError", "");
        },
        ClearErrorAsync: async (context) => {
            context.commit("SetError", "");
        }
    },
    mutations: {
        SetLoading: (state, payload) => {
            state.isLoading = payload;
        },
        AddSuccess: (state, payload) => {
            state.successMessages = [...state.successMessages, payload];
        },
        RemoveSuccess: (state) => {
            const tempState = [...state.successMessages];
            tempState.shift();

            state.successMessages = [...tempState];
        },
        SetError: (state, error) => {
            state.error = error;
        }
    },
    modules: {
        coursesModule: CoursesModule,
        studentsModule: StudentsModule,
        gradesModule: GradesModule
    }
});