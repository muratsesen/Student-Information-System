import { useParams, Link, useNavigate } from "react-router-dom";
import { useEffect, useReducer } from "react";
import { useCreateStudentMutation,useUpdateStudentMutation,useMufredatlarQuery,useStudentDetailsQuery } from "../features/apiSlice";


const initialState = {
  ogrenciId: 0,
  mufredatId: 0,
  iletisimId: 0,
  kimlikId: 0,
  ad: '',
  soyad: '',
  ogrenciNo: '',
  adres: '',
  il: '',
  ilce: '',
  email: '',
  gsm: '',
  tckNo: '',
  dogumYeri: '',
  dogumTarihi: '',
};


const reducer = (state, action) => {
  switch (action.type) {
    case 'setValues':
      return { ...state, ...action.payload };
    default:
      return state;
  }
};

const NewStudent = () => {
  const navigate = useNavigate();
  const { id } = useParams();

  const [state, dispatch] = useReducer(reducer, initialState);

  const [createUser,{isSuccess:studentCreated}] = useCreateStudentMutation();//, { isLoading, isSuccess, isError, error }
  const [updateUser] = useUpdateStudentMutation();
  const { data: mufredatlar } = useMufredatlarQuery();
  const { data: user, isError, isLoading,isSuccess } = useStudentDetailsQuery({ id });
useEffect(() => {
  if(studentCreated){
    navigate(-1);
  }
},[studentCreated]);
  useEffect(() => {
    if (isSuccess && user) {
      // Set initial state values when user data is available
      console.log('User Data:', user);
      const userState = {...user};
      delete userState.MufredatName;
      dispatch({ type: 'setValues', payload: userState });
    }
  }, [isSuccess, user]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    dispatch({ type: 'setValues', payload: { [name]: value } });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Here you can submit the state data
    console.log('Submitted State:', state);
    if(id){
      updateUser(state);
    }
    else{
      createUser(state);
    }
  };


  
return (
    <div>
      {id ? <h1> Öğrenci Düzenle </h1> : <h1> Yeni Öğrenci </h1>}
      <p className="text-blue-400 cursor-pointer" onClick={() => navigate(-1)}>
        Geri dön
      </p>
      <br />
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="ad"
          placeholder="ad"
          value={state.ad}
          onChange={handleChange}
        />
        <input
          type="text"
          name="soyad"
          placeholder="soyad"
          value={state.soyad}
          onChange={handleChange}
        />
        <input
          type="text"
          name="ogrenciNo"
          placeholder="Öğrenci No"
          value={state.ogrenciNo}
          onChange={handleChange}
        />
        <input
          type="text"
          name="adres"
          placeholder="Adres"
          value={state.adres}
          onChange={handleChange}
        />
        <input
          type="text"
          name="il"
          placeholder="İl"
          value={state.il}
          onChange={handleChange}
        />
        <input
          type="text"
          name="ilce"
          placeholder="İlçe"
          value={state.ilce}
          onChange={handleChange}
        />
        <input
          type="text"
          name="email"
          placeholder="email"
          value={state.email}
          onChange={handleChange}
        />
        <input
          type="text"
          name="gsm"
          placeholder="GSM"
          value={state.gsm}
          onChange={handleChange}
        />
        <input
          type="text"
          name="tckNo"
          placeholder="TC Kimlik No"
          value={state.tckNo}
          onChange={handleChange}
        />

        <input
          type="text"
          name="dogumYeri"
          placeholder="Doğum Yeri"
          value={state.dogumYeri}
          onChange={handleChange}
        />
        <input
          type="date"
          name="dogumTarihi"
          placeholder="Doğum Tarihi"
          value={formatDate(state.dogumTarihi)}
          onChange={handleChange}
        />
        <select
          name="mufredatId"
          value={state.mufredatId}
          onChange={handleChange}
        >
          {mufredatlar?.map((mufredat) => (
            <option 
            key={mufredat.id} 
            value={mufredat.id}>{mufredat.name}</option>
          ))
          }
        </select>
        <br />
        <br />
        <button type="submit">Kaydet</button>
      </form>

    </div>
  );
};

export default NewStudent;


const formatDate = (dateString) => {
  const parsedDate = new Date(dateString);
  const year = parsedDate.getFullYear();
  const month = String(parsedDate.getMonth() + 1).padStart(2, "0"); // Add 1 to month since it's 0-based
  const day = String(parsedDate.getDate()).padStart(2, "0");

  return `${year}-${month}-${day}`;
};