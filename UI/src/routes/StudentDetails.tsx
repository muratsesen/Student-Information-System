import { useParams, Link, useNavigate } from "react-router-dom";
import { useAppSelector } from "../app/hooks";
import { useStudentDetailsQuery  } from "../features/apiSlice"
import { Button } from "@mantine/core";


const StudentDetails = () => {
  const navigate = useNavigate();
  const { id } = useParams();

  const { data: user, isError, isLoading } = useStudentDetailsQuery({ id });
  if (isError) {
    return <div>Hata!</div>;
  }

  if (isLoading) {
    return <div>Yükleniyor...</div>;
  }

  return (
    <div>
      <h1>Kullanıcı Detayları</h1><span className="text-blue-400 cursor-pointer"
        onClick={() => navigate(-1)}>
        Geri Dön
      </span>

      <br />
      <br />
      <div className="container mx-auto mt-8">

        <span className="text-blue-400 cursor-pointer "
          onClick={() => navigate("/new-user/" + id)}>
          Düzenle
        </span>
        <table className="min-w-full table-auto">

          <tbody>
            <tr>
              <td className="border px-4 py-2">Kimlik No</td>
              <td className="border px-4 py-2">{user.tckNo}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Öğrenci No</td>
              <td className="border px-4 py-2">{user.ogrenciNo}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Ad</td>
              <td className="border px-4 py-2">{user.ad}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Soyad</td>
              <td className="border px-4 py-2">{user.soyad}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Doğum Yeri</td>
              <td className="border px-4 py-2">{user.dogumYeri}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Dogum Tarihi</td>
              <td className="border px-4 py-2">{user.dogumTarihi}</td>
            </tr>

            <tr>
              <td className="border px-4 py-2">Adres</td>
              <td className="border px-4 py-2">{user.adres}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">İl</td>
              <td className="border px-4 py-2">{user.il}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">ilce</td>
              <td className="border px-4 py-2">{user.ilce}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">Email</td>
              <td className="border px-4 py-2">{user.email}</td>
            </tr>
            <tr>
              <td className="border px-4 py-2">GSM</td>
              <td className="border px-4 py-2">{user.gsm}</td>
            </tr>

          
          </tbody>
        </table>
      </div>

    </div>
  );
};

export default StudentDetails;
