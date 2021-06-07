import { talks, Talk } from "../api/mock";
import styles from "../../styles/Talks.module.css";
import { useRouter } from "next/router";

export default function Talks({ talks }: { talks: Array<Talk> }) {
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
        </div>
      ))}
    </div>
  );
}

export async function getStaticProps({ params }: { params: { id: number } }) {
  console.log(params.id);
  return {
    props: { talks },
  };
}
export async function getStaticPaths() {
  return {
    paths: [{ params: { id: "1" } }, { params: { id: "2" } }],
    fallback: true,
  };
}
