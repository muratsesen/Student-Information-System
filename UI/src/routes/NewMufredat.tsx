import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useReducer } from "react";
import {
  useLessonsQuery, useMufredatQuery,
  useCreateMufredatMutation,
  useUpdateMufredatMutation
} from "../features/apiSlice";
import ToastNotify from "../components/ToastNotify";


const initialState = {
  name: '',
  lessons: [],
};


const reducer = (state, action) => {
  switch (action.type) {
    case "setValues":
      return { ...state, ...action.payload };
    case "toggleLesson":
      const lessonId = action.payload;
      const updatedLessons = state.lessons.includes(lessonId)
        ? state.lessons.filter((id) => id !== lessonId)
        : [...state.lessons, lessonId];
      return { ...state, lessons: updatedLessons };
    default:
      return state;
  }
};

const NewMufredat = () => {
  const navigate = useNavigate();
  const { id } = useParams();

  const [state, dispatch] = useReducer(reducer, initialState);

  const [createMufredat, { isSuccess: mufredatCreateSuccess }] = useCreateMufredatMutation();//, { isLoading, isSuccess, isError, error }
  const [updateMufredat, { isSuccess: mufredatUpdateSuccess }] = useUpdateMufredatMutation();

  const { data: mufredat, isError, isLoading, isSuccess } = useMufredatQuery({ id });
  const { data: lessons } = useLessonsQuery();

  useEffect(() => {
    if (mufredatCreateSuccess || mufredatUpdateSuccess) {
      ToastNotify("MÜFREDAT KAYDEDILDI!");
      navigate(-1);
    }

  }, [mufredatCreateSuccess, mufredatUpdateSuccess]);

  useEffect(() => {
    if (isSuccess && mufredat) {

      const userState = { ...mufredat, lessons: mufredat.lessons.map((lesson) => lesson.dersid) };
      delete userState.MufredatName;
      dispatch({ type: 'setValues', payload: userState });
    }
  }, [isSuccess, mufredat]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    dispatch({ type: 'setValues', payload: { [name]: value } });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you can submit the state data
    console.log('Submitted State:', state);
    if (id) {
      updateMufredat(state);
    }
    else {
      createMufredat(state);
    }
  };
  const handleLessonToggle = (lessonId) => {
    dispatch({ type: 'toggleLesson', payload: lessonId });
  };


  return (
    <div>
      {id ? <h1> Müfredat Düzenle </h1> : <h1> Yeni Müfredat </h1>}
      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>
      <br />
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="Müfredat Adı"
          value={state.name}
          onChange={handleChange}
        />

        {/* lesson list */}
        <div className="mt-4">
          <p className="font-bold">Dersler:</p>
          {lessons &&
            lessons.map((lesson) => (
              <div key={lesson.id} className="flex items-center mt-2">
                <input
                  type="checkbox"
                  id={`lesson-${lesson.id}`}
                  name={`lesson-${lesson.id}`}
                  checked={state.lessons.includes(lesson.id)}
                  onChange={() => handleLessonToggle(lesson.id)}
                />
                <label
                  htmlFor={`lesson-${lesson.id}`}
                  className="ml-2 cursor-pointer"
                >
                  {lesson.name}
                </label>
              </div>
            ))}
        </div>

        <br />
        <br />
        <button type="submit">Kaydet</button>
      </form>

    </div>
  );
};

export default NewMufredat;
