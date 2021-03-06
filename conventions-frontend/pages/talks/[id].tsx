import styles from "../../styles/Talks.module.css";
import { useRouter } from "next/router";
import ReserveSeat from "../../components/ReserveSeat";
import { Convention, Talk } from "../api/models";
export default function Talks({ talks }: { talks: Array<Talk> }) {
  const router = useRouter();
  const { id } = router.query;
  return (
    <div className={styles.talks}>
      <h1>Talks</h1>
      {talks.map((talk) => (
        <div className={styles.talk} key={talk.id}>
          <h2>{talk.topic}</h2>
          <p>
            by <strong>{talk.speaker}</strong>
          </p>
          <p>{talk.description}</p>
          <ReserveSeat conventionId={Number(id)} talk={talk}></ReserveSeat>
        </div>
      ))}
    </div>
  );
}

export async function getStaticProps({ params }: { params: { id: number } }) {
  const serverUrl = process.env.REACT_APP_SERVER_URL;
  const response = await (
    await fetch(`${serverUrl}/conventions/${params.id}/talks`)
  ).json();
  console.log(response);
  return {
    props: { talks: response },
  };
}
export async function getStaticPaths() {
  const serverUrl = process.env.REACT_APP_SERVER_URL;
  const response = await (await fetch(`${serverUrl}/conventions`)).json();
  console.log("RES", response);
  return {
    paths: response.map((x: Convention) => ({
      params: { id: x.id.toString() },
    })),
    fallback: true,
  };
}
