import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useReducer } from "react";
import {
  useCreateLessonMutation,
  useUpdateLessonMutation,
  useLessonContentQuery
} from "../features/apiSlice";
import ToastNotify from "../components/ToastNotify";


const initialState = {
  id: 0,
  name: '',
  code: '',
  status: 1,
  credit: '',
};


const reducer = (state, action) => {
  switch (action.type) {
    case 'setValues':
      return { ...state, ...action.payload };
    default:
      return state;
  }
};

const NewLesson = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [createLesson,{isSuccess:lessonCreateSuccess}] = useCreateLessonMutation();
  const [updateLesson,{isSuccess:lessonUpdateSuccess}] = useUpdateLessonMutation();
  const [state, dispatch] = useReducer(reducer, initialState);
  const { data: lesson, isError, isLoading, isSuccess } = useLessonContentQuery({ id });

  useEffect(() => {
    if (isSuccess && lesson) {
      const userState = { ...lesson };
      dispatch({ type: 'setValues', payload: userState });
    }
  }, [isSuccess, lesson]);

  useEffect(() => {
    if (lessonCreateSuccess || lessonUpdateSuccess) {
      ToastNotify("DERS KAYDEDILDI!");
      navigate(-1);
    }

  }, [lessonCreateSuccess, lessonUpdateSuccess]);

  const handleChange = (e) => {
    const { name, value, checked } = e.target;

    if (name === 'status') {
      // Toggle the status between 1 and 0
      dispatch({ type: 'setValues', payload: { [name]: checked ? 1 : 0 } });
    } else {
      dispatch({ type: 'setValues', payload: { [name]: value } });
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you can submit the state data
    console.log('Submitted State:', state);
    if (id > 0) {
      updateLesson(state);
    }
    else {
      createLesson(state);
    }
  };


  return (
    <div>
      {id ? <h1> Ders Düzenle </h1> : <h1> Yeni Ders </h1>}
      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>
      <br />
      <form onSubmit={handleSubmit}>
        <div>
          <label>
            Ders Adı:
            <input
              type="text"
              name="name"
              placeholder="Ders Adı"
              value={state.name}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          <label>
            Ders Kodu:
            <input
              type="text"
              name="code"
              placeholder="Ders Kodu"
              value={state.code}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          <label>
            Kredi:
            <input
              type="number"
              name="credit"
              min="1"
              max={20}
              placeholder="Kredi"
              value={state.credit}
              onChange={handleChange}
            />
          </label>
        </div>
        <br />
        <div>
          {state.status === 1 ? (
            <label>
              <input
                type="checkbox"
                name="status"
                value={state.status}
                checked={state.status}
                onChange={handleChange}
              />
              Aktif
            </label>
          ) : (
            <label>
              <input
                type="checkbox"
                name="status"
                value={state.status}
                checked={state.status}
                onChange={handleChange}
              />
              Pasif
            </label>
          )}
        </div>




        <br />
        <br />
        <button type="submit">Kaydet</button>
      </form>

    </div>
  );
};

export default NewLesson;

